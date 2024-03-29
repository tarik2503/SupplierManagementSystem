import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Supplier } from '../../../models/supplier.model';
import { Product } from '../../../models/product.model';
import PONumberGenerator from '../../../helpers/poNumberGenerator';
import { Router } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import { ProductService } from '../../../services/product.service';

@Component({
  selector: 'app-add-purchase-order',
  templateUrl: './add-purchase-order.component.html',
  styleUrl: './add-purchase-order.component.css'
})
export class AddPurchaseOrderComponent {
  purchaseOrderForm!: FormGroup;
  suppliers: Supplier[] = [];
  products:Product[] = [];
  productCostPrice!: number;
  productsMap: Map<string, number> = new Map();
  obj = new PONumberGenerator();
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private supplierService: SupplierService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    var poUniqueNumber = this.obj.generateNextPONumber();

    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
        console.log(this.suppliers);
      },
      error: (response) => {
        console.log(response);
      },
    });

    this.purchaseOrderForm = this.fb.group({
      supplierId: ['', Validators.required],
      poNumber: [
        { value: poUniqueNumber, disabled: true },
        Validators.required,
      ],
      deliveryDate:[
        '',Validators.required
      ],
      productId:['', Validators.required],
      quantity:[0, [Validators.required, Validators.min(1), Validators.max(100)]],
    });


    this.purchaseOrderForm.get('supplierId')!.valueChanges.subscribe(supplierId => {
      if (supplierId) {
        this.productService.getAllProducts().subscribe(products => {
          this.products = products;
          products.forEach(product => {
            this.productsMap.set(product.id, product.sellingPrice);
          });
          
        });
      }
    });


    this.purchaseOrderForm.get('productId')!.valueChanges.subscribe(productId => {
      if(productId){
       this.productCostPrice = this.productsMap.get(productId) || 0 ;
      }
      
    });
  }

  calculatePrice(): number {
    const productQuantity = this.purchaseOrderForm.get('quantity')?.value || 0;
    const pricePerUnit = this.productCostPrice
    return productQuantity * pricePerUnit;
  }

  onSave(){
    
  }
}
