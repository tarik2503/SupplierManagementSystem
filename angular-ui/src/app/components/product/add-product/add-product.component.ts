import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../../models/product.model';
import { ActivatedRoute, Router } from '@angular/router';
import ValidateForm from '../../../helpers/validateform';
import { SupplierService } from '../../../services/supplier.service';
import { Supplier } from '../../../models/supplier.model';
import { ProductService } from '../../../services/product.service';
import { ImagePathService } from '../../../services/image-path.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css',
})
export class AddProductComponent implements OnInit {
  addProductForm!: FormGroup;
  image!:File
  suppliers: Supplier[] = [];
  mode!: 'add' | 'edit' ;
  productId!: string;
  imageURL!: string;
  formHeading!: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private supplierService: SupplierService,
    private productService: ProductService,
    private imagePathService: ImagePathService
  ) {}

  ngOnInit(): void {
    this.formInitialize();
    this.getSuppliers();
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.mode = 'edit';
        this.formHeading = 'Edit Product'
        this.productId = params['id'];
        this.loadProduct(this.productId);
      } else {
        this.mode = 'add';  
        this.formHeading = 'Add New Product'
      }
    }); 
  }

  formInitialize(): void{
    this.addProductForm = this.fb.group({
      title: new FormControl('', Validators.required),
      productSKU:new FormControl ('', Validators.required),
      costPrice: new FormControl (
        '',
        [Validators.required, Validators.min(0.1)],
    ),
      sellingPrice: new FormControl(
        '',
        [Validators.required, Validators.min(0.1)],
      ),
      supplierId:new FormControl('', Validators.required),
    });

  }

  loadProduct(id: string) {
    this.productService.getProduct(id).subscribe((response) => {
      this.addProductForm.patchValue(response);
      this.imageURL = this.imagePathService.getImageFullPath(response.imagePath);
    });

  }

  getSuppliers():void{
    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  onSave() {
    if (this.addProductForm.valid) {
      var product:Product = this.addProductForm.value as Product;
      var formData = new FormData();
      formData.append('image', this.image);
      formData.append('product',JSON.stringify(product))
      if (this.mode === 'add') {
       this.productService.addProduct(formData).subscribe({
         next: (response) => {
           console.log(response);
           this.router.navigate(['productlist']);
         },
       });
     } else if (this.mode === 'edit') {
       this.productService.updateProduct(this.productId, formData).subscribe({
         next: (response) => {
           console.log(response);
           this.router.navigate(['productlist']);
         },
       });
     }
    } else {
      ValidateForm.validateAllFormFields(this.addProductForm);
    }
  }

  //upload image and adding to api resource folder
  uploadFile (evt:any) {
    this.image =evt.target.files[0];

    //Show image preview
    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageURL = event.target.result;
    };
    reader.readAsDataURL(this.image);

    
  }

  calculateProfit(): number {
    const costPrice = this.addProductForm.get('costPrice')?.value || 0;
    const sellingPrice = this.addProductForm.get('sellingPrice')?.value || 0;
    return sellingPrice - costPrice;
  }
}
