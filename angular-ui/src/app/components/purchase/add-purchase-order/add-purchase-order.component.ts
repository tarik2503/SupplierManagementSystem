import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Supplier } from '../../../models/supplier.model';
import { Product } from '../../../models/product.model';
import PONumberGenerator from '../../../helpers/poNumberGenerator';
import { Router } from '@angular/router';
import { SupplierService } from '../../../services/supplier.service';
import { ProductService } from '../../../services/product.service';
import ValidateForm from '../../../helpers/validateform';
import { PurchaseorderService } from '../../../services/purchaseorder.service';
import { LastPONumberService } from '../../../services/last-ponumber.service';

@Component({
  selector: 'app-add-purchase-order',
  templateUrl: './add-purchase-order.component.html',
  styleUrl: './add-purchase-order.component.css',
})
export class AddPurchaseOrderComponent {
  purchaseOrderForm!: FormGroup;
  suppliers: Supplier[] = [];
  products: Product[] = [];
  productCostPrice!: number;
  productsMap: Map<string, number> = new Map();
  poUniqueNumber!: string;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private supplierService: SupplierService,
    private productService: ProductService,
    private purchaseOrder: PurchaseorderService,
    private lastPONumberService: LastPONumberService
  ) {}

  ngOnInit(): void {
    const obj = new PONumberGenerator(this.lastPONumberService);
    this.poUniqueNumber = obj.generateNextPONumber();
    this.getSuppliers();
    this.formInitialize();
    this.addProductRow();
    this.onSupplierChangeProductFetched();
  }

  formInitialize(): void {
    this.purchaseOrderForm = this.fb.group({
      supplierId: new FormControl('', Validators.required),
      poNumber: new FormControl(
        { value: this.poUniqueNumber, disabled: true },
        Validators.required,
      ),
      deliveryDate: new FormControl('', Validators.required),
      products: this.fb.array([]),
    });
  }

  getSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  onSupplierChangeProductFetched(): void {
    this.purchaseOrderForm
      .get('supplierId')!
      .valueChanges.subscribe((supplierId) => {
        if (supplierId) {
          this.productService
            .getProductsBySupplierId(supplierId)
            .subscribe((products) => {
              this.products = products;
              products.forEach((product) => {
                this.productsMap.set(product.id, product.sellingPrice);
              });
            });
        }
      });
  }

  calculatePrice(productId: string, quantity: number): number {
    const productCostPrice = this.productsMap.get(productId) || 0;
    return quantity * productCostPrice;
  }

  addProductRow() {
    const productRow = this.fb.group({
      productId:new FormControl ('', Validators.required),
      quantity: new FormControl(
        0,
        [Validators.required, Validators.min(1), Validators.max(100)],
      ),
    });
    this.productsArray.push(productRow);
  }

  removeProductRow(index: number) {
    if (this.productsArray.length > 1) {
      this.productsArray.removeAt(index);
    }
  }

  get productsArray() {
    return this.purchaseOrderForm.get('products') as FormArray;
  }

  onSave() {
    if (this.purchaseOrderForm.valid) {
      this.purchaseOrder
        .createPurchaseOrder(this.purchaseOrderForm.getRawValue())
        .subscribe({
          next: (response) => {
            this.router.navigate(['purchaseorderlist']);
          },
        });
    } else {
      ValidateForm.validateAllFormFields(this.purchaseOrderForm);
    }
  }
}
