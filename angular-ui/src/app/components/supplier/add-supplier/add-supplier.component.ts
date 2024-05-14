import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import ValidateForm from '../../../helpers/validateform';
import { Supplier } from '../../../models/supplier.model';
import { ImagePathService } from '../../../services/image-path.service';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrl: './add-supplier.component.css',
})
export class AddSupplierComponent implements OnInit {
  addSupplierForm!: FormGroup;
  image!: File;
  imageURL!: string;
  mode!: 'add' | 'edit';
  supplierId!: string;
  formHeading!: string;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private supplierService: SupplierService,
    private imagePathService:ImagePathService
  ) {}

  ngOnInit(): void {
    this.formInitialize();
    this.modeChecking();
  }

  
  modeChecking(){
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.mode = 'edit';
        this.formHeading='Edit Supplier';
        this.supplierId = params['id'];
        this.loadSupplier(this.supplierId);
      } else {
        this.mode = 'add';  
        this.formHeading='Add New Supplier';
      }
    });
  }

  formInitialize(): void {
    this.addSupplierForm = this.fb.group({
      supplierName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      phone: new FormControl(
        '',
        [Validators.required, Validators.pattern(/^\(?\d{5}\)?[-.\s]?\d{5}$/)],
      ),
      street: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      state: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      zipCode: new FormControl('', Validators.required),
    });
  }


  loadSupplier(id: string) {
    this.supplierService.getSupplier(id).subscribe((response) => {
      this.addSupplierForm.patchValue(response);
      this.imageURL = `'${this.imagePathService.getImageFullPath(response.imgPath)}'`;
    });

  }

  onSave() {
    if (this.addSupplierForm.valid) {       
   var supplier:Supplier = this.addSupplierForm.value as Supplier;
   var formData = new FormData();
   formData.append('image', this.image);
   formData.append('supplier',JSON.stringify(supplier))
   if (this.mode === 'add') {
    this.supplierService.addSupplier(formData).subscribe({
      next: (response) => {
        this.router.navigate(['supplierlist']);
      },
    });
  } else if (this.mode === 'edit') {
    this.supplierService.updateSupplier(this.supplierId, formData).subscribe({
      next: (response) => {
        this.router.navigate(['supplierlist']);
      },
    });
  }
    } else {
      ValidateForm.validateAllFormFields(this.addSupplierForm);
    }
  }

  //upload image and adding to api resource folder
  uploadFile(evt: any){
    this.image =evt.target.files[0];
   
    //Show image preview
    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageURL = event.target.result;
    };
    reader.readAsDataURL(this.image);  
  }
}
