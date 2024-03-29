import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import ValidateForm from '../../../helpers/validateform';
import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Supplier } from '../../../models/supplier.model';

@Component({
  selector: 'app-edit-supplier',
  templateUrl: './edit-supplier.component.html',
  styleUrl: './edit-supplier.component.css',
})
export class EditSupplierComponent {
  supplier!: Supplier;
  supplierId!: string;
  editSupplierForm!: FormGroup;
  response!: { dbPath: '' };

  progress!: number;
  message!: string;
  imageURL!: string;
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private supplierService: SupplierService
  ) {}

  ngOnInit(): void {
    this.supplier = {
      id: '00000000-0000-0000-0000-000000000000',
      supplierName: '',
      email: '',
      phone: '',
      street: '',
      city: '',
      state: '',
      country: '',
      zipCode: '',
      imgPath: '',
    };

    this.editSupplierForm = this.fb.group({
      supplierName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: [
        '',
        [Validators.required, Validators.pattern(/^\(?\d{5}\)?[-.\s]?\d{5}$/)],
      ],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      country: ['', Validators.required],
      zipCode: ['', Validators.required],
    });

    this.route.params.subscribe((params) => {
      this.supplierId = params['id'];
      this.getSupplier(this.supplierId);
    });

    this.editSupplierForm.valueChanges.subscribe((data) => {
      this.supplier = { ...this.supplier, ...data };
    });
  }

  getSupplier(id: string) {
    this.supplierService.getSupplier(id).subscribe((response) => {
      this.editSupplierForm.patchValue(response);
      this.supplier.imgPath = response.imgPath;
      this.imageURL = this.supplierService.getImageFullPath(response.imgPath);
    });

  }

  onUpdate() {
    if (this.editSupplierForm.valid) {
      if (this.response && this.response.dbPath) {
        this.supplier.imgPath = this.response.dbPath; // Update imgPath with the new image path
      }

      this.supplierService
        .updateSupplier(this.supplierId, this.supplier)
        .subscribe({
          next: (supplier) => {
            this.router.navigate(['supplierlist']);
          },
        });
    } else {
      ValidateForm.validateAllFormFields(this.editSupplierForm);
    }
  }

  //upload image and adding to api resource folder
  uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    //Show image preview
    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageURL = event.target.result;
    };
    reader.readAsDataURL(fileToUpload);

    this.supplierService.uploadImage(formData).subscribe({
      next: (event) => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round((100 * event.loaded) / (event.total || 1));
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.uploadFinished(event.body);
        }
      },
      error: (err: HttpErrorResponse) => console.log(err),
    });
  };

  public uploadFinished(event: any) {
    this.response = event;
  }
}
