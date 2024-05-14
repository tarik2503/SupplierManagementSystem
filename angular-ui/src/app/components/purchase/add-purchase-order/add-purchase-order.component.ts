import { Component } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Supplier } from '../../../models/supplier.model';
import { Product } from '../../../models/product.model';
import PONumberGenerator from '../../../helpers/poNumberGenerator';
import { ActivatedRoute, Router } from '@angular/router';
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
  addedProducts: any[] = [];
  selectedSupplier!: Supplier;
  currentDate = new Date();
  totalInvoiceAmount: number = 0;
  mode!: 'add' | 'edit';
  formHeading!: string;
  purchaseOrderId!: string;
  supplierId!: string
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private supplierService: SupplierService,
    private productService: ProductService,
    private purchaseOrderService: PurchaseorderService,
    private lastPONumberService: LastPONumberService,
    
  ) {}

  ngOnInit(): void {   
    this.getSuppliers();
    this.formInitialize();
    this.modeChecking();
    this.addProductRow();
    this.onSupplierChangeProductFetched();   
  }

  modeChecking(){
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.mode = 'edit';
        this.formHeading='Edit Purchase Order';
        this.purchaseOrderId = params['id'];
        this.loadPurchaseOrder(this.purchaseOrderId);  
      } else {
        this.mode = 'add'; 
        this.poNumberGenerate(); 
        this.formHeading='Add Purchase Order';
      }
    });
  }

  loadPurchaseOrder(id: string) {
  this.purchaseOrderService.getPurchaseOrder(id).subscribe((response) => {
    this.supplierId = response.supplierId;
    this.purchaseOrderForm.patchValue({
      ...response,
      deliveryDate: response.deliveryDate ? new Date(response.deliveryDate).toISOString().substring(0, 10) : null,
      products: undefined
    });
    this.poUniqueNumber = response.poNumber
    const products: any[] = response.products || [];
    this.productsArray.clear(); 
    this.addedProducts = [];
    products.forEach(product => {
      this.addProductRow(product); 
    });
  });
  
}

  async poNumberGenerate() {
    const obj = new PONumberGenerator(this.lastPONumberService);
    this.poUniqueNumber = await obj.generateNextPONumber();
    this.purchaseOrderForm.patchValue({
      poNumber: this.poUniqueNumber,
    });
  }

  formInitialize(): void {
    this.purchaseOrderForm = this.fb.group({
      supplierId: new FormControl('', Validators.required),
      poNumber: new FormControl(
        { value: this.poUniqueNumber, disabled: true },
        Validators.required
      ),
      deliveryDate: new FormControl('', Validators.required),
      products: this.fb.array([]),
    });

  this.productsArray.controls.forEach((control, index) => {
    control.valueChanges.subscribe(value => {
      this.addedProducts[index] = value;
      this.calculateTotalInvoiceAmount();
    });
  });
  }

    getSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
        if(this.supplierId !== ''){
          this.selectedSupplier = this.suppliers.find(x=>x.id == this.supplierId)!
        }
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
           this.selectedSupplier = this.suppliers.find((o) => o.id == supplierId)!
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

  getProductTitle(id: string): string {   
    let obj = this.products.find((o) => o.id === id);
    return obj?.title || 'Not Found';
  }
  
  getProductSellingPrice(id: string): number {
    let obj = this.products.find((o) => o.id === id);
    return obj?.sellingPrice || 0;
  }

  addProductRow(product?:any) {
    const productRow = this.fb.group({
      productId: new FormControl(product?.productId || '', Validators.required),
      quantity: new FormControl(product?.quantity || 0, [
        Validators.required,
        Validators.min(1),
        Validators.max(100),
      ]),
    });

// Subscribe to value changes for the new product row
  productRow.valueChanges.subscribe(value => {
    const index = this.productsArray.controls.indexOf(productRow);
    this.addedProducts[index] = value;
    this.calculateTotalInvoiceAmount();
  });

    this.productsArray.push(productRow);

    
      this.addedProducts.push({
        productId: product?.productId || '',
        quantity: product?.quantity || 0,
      }); 
  }

  removeProductRow(index: number) {
    if (this.productsArray.length > 1) {
      this.productsArray.removeAt(index);
      this.addedProducts.splice(index, 1);
      this.calculateTotalInvoiceAmount();
    }
  }

  calculateTotalInvoiceAmount() {
    this.totalInvoiceAmount = this.addedProducts.reduce((total, product) => {
      const price = this.calculatePrice(product.productId, product.quantity);
      return total + price;
    }, 0);
  }

  get productsArray() {
    return this.purchaseOrderForm.get('products') as FormArray;
  }

  onSave() {
    if (this.purchaseOrderForm.valid) {
      if (this.mode === 'add') {
        this.purchaseOrderService
        .createPurchaseOrder(this.purchaseOrderForm.getRawValue())
        .subscribe({
          next: (response) => {
            this.router.navigate(['purchaseorderlist']);
          },
        });
      } else if (this.mode === 'edit') {
        this.purchaseOrderService.updatePurchaseOrder(this.purchaseOrderId, this.purchaseOrderForm.getRawValue()).subscribe({
          next: (response) => {
            console.log(response);
            this.router.navigate(['purchaseorderlist']);
          },
        });
      }
    } else {
      ValidateForm.validateAllFormFields(this.purchaseOrderForm);
    }
  }
}
