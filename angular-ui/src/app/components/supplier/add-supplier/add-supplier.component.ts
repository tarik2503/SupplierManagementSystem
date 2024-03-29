import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import ValidateForm from '../../../helpers/validateform';
import {
  HttpErrorResponse,
  HttpEventType,
  HttpResponse,
} from '@angular/common/http';
import { Supplier } from '../../../models/supplier.model';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrl: './add-supplier.component.css',
})
export class AddSupplierComponent implements OnInit {
  addSupplierForm!: FormGroup;
  response!: { dbPath: '' };
  supplier!: Supplier;

  progress!: number;
  message!: string;
  imageURL!: string;

  constructor(
    private fb: FormBuilder,
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

    this.addSupplierForm = this.fb.group({
      supplierName: [this.supplier.supplierName, Validators.required],
      email: [this.supplier.email, [Validators.required, Validators.email]],
      phone: [
        this.supplier.phone,
        [Validators.required, Validators.pattern(/^\(?\d{5}\)?[-.\s]?\d{5}$/)],
      ],
      street: [this.supplier.street, Validators.required],
      city: [this.supplier.city, Validators.required],
      state: [this.supplier.state, Validators.required],
      country: [this.supplier.country, Validators.required],
      zipCode: [this.supplier.zipCode, Validators.required],
    });

    this.addSupplierForm.valueChanges.subscribe((data) => {
      this.supplier = { ...this.supplier, ...data };
    });
  }

  onSave() {
    if (this.addSupplierForm.valid) {
      this.supplier.imgPath = this.response.dbPath;
      this.supplierService.addSupplier(this.supplier).subscribe({
        next: (response) => {
          this.router.navigate(['supplierlist']);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.addSupplierForm);
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
