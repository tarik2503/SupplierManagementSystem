import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../../models/product.model';
import { Router } from '@angular/router';
import ValidateForm from '../../../helpers/validateform';
import { SupplierService } from '../../../services/supplier.service';
import { Supplier } from '../../../models/supplier.model';
import { ProductService } from '../../../services/product.service';
import { HttpErrorResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css',
})
export class AddProductComponent implements OnInit {
  addProductForm!: FormGroup;
  product!: Product;
  suppliers: Supplier[] = [];
  response!: { dbPath: '' };

  progress!: number;
  message!: string;
  imageURL!: string;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private supplierService: SupplierService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
      },
      error: (response) => {
        console.log(response);
      },
    });

    this.product = {
      id: '00000000-0000-0000-0000-000000000000',
      title: '',
      productSKU: '',
      costPrice: 0,
      sellingPrice: 0,
      supplierId: '',
      imagePath: '',
    };
    this.addProductForm = this.fb.group({
      title: [this.product.title, Validators.required],
      productSKU: [this.product.productSKU, Validators.required],
      costPrice: [
        this.product.costPrice,
        [Validators.required, Validators.min(0.1)],
      ],
      sellingPrice: [
        this.product.sellingPrice,
        [Validators.required, Validators.min(0.1)],
      ],
      supplierId: [this.product.supplierId, Validators.required],
    });

    this.addProductForm.valueChanges.subscribe((data) => {
      this.product = { ...this.product, ...data };
    });
  }

  onSave() {
    if (this.addProductForm.valid) {
      this.product.imagePath = this.response.dbPath;
      this.productService.addProduct(this.product).subscribe({
        next: (response) => {
          this.router.navigate(['productlist']);
        },
        error: (err) => {
          console.error('Error:', err);
          const errorMessage =
            err && err.error && err.error.message
              ? err.error.message
              : 'An error occurred';
          alert(errorMessage);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.addProductForm);
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

  calculateProfit(): number {
    const costPrice = this.addProductForm.get('costPrice')?.value || 0;
    const sellingPrice = this.addProductForm.get('sellingPrice')?.value || 0;
    return sellingPrice - costPrice;
  }
}
