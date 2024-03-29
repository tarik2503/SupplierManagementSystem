import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../../models/product.model';
import { SupplierService } from '../../../services/supplier.service';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import ValidateForm from '../../../helpers/validateform';
import { Supplier } from '../../../models/supplier.model';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css',
})
export class EditProductComponent implements OnInit {
  editProductForm!: FormGroup;
  product!: Product;
  productId!: string;
  response!: { dbPath: '' };
  suppliers: Supplier[] = [];

  progress!: number;
  message!: string;
  imageURL!: string;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private supplierService: SupplierService,
    private productService: ProductService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.product = {
      id: '00000000-0000-0000-0000-000000000000',
      title: '',
      productSKU: '',
      costPrice: 0,
      sellingPrice: 0,
      supplierId: '',
      imagePath: '',
    };
    this.editProductForm = this.fb.group({
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

    this.route.params.subscribe((params) => {
      this.productId = params['id'];
      this.getProduct(this.productId);
    });

    // Fetch all departments
    this.supplierService.getAllSuppliers().subscribe({
      next: (supp) => {
        this.suppliers = supp;
      },
      error: (response) => {
        console.log(response);
      },
    });

    this.editProductForm.valueChanges.subscribe((data) => {
      this.product = { ...this.product, ...data };
    });
  }

  getProduct(id: string) {
    this.productService.getProduct(id).subscribe((response) => {
      this.editProductForm.patchValue(response);
      this.product.imagePath = response.imagePath;
      this.imageURL = this.supplierService.getImageFullPath(response.imagePath);
    });
  }

  onUpdate() {
    if (this.editProductForm.valid) {
      if (this.response && this.response.dbPath) {
        this.product.imagePath = this.response.dbPath; // Update imgPath with the new image path
      }

      this.productService
        .updateProduct(this.productId, this.product)
        .subscribe({
          next: (product) => {
            this.router.navigate(['productlist']);
          },
        });
    } else {
      ValidateForm.validateAllFormFields(this.editProductForm);
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
    const costPrice = this.editProductForm.get('costPrice')?.value || 0;
    const sellingPrice = this.editProductForm.get('sellingPrice')?.value || 0;
    return sellingPrice - costPrice;
  }
}
