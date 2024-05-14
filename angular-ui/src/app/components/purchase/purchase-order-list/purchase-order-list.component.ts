import { Component } from '@angular/core';
import { PurchaseOrder } from '../../../models/purchaseorder.model';
import { SupplierService } from '../../../services/supplier.service';
import { PurchaseorderService } from '../../../services/purchaseorder.service';

@Component({
  selector: 'app-purchase-order-list',
  templateUrl: './purchase-order-list.component.html',
  styleUrl: './purchase-order-list.component.css'
})
export class PurchaseOrderListComponent {
  purchaseOrders: PurchaseOrder[] = [];
  suppliersMap: Map<string, string> = new Map();

  constructor(
    private purchaseOrderService: PurchaseorderService,
    private supplierService: SupplierService
  ) {}

  ngOnInit(): void {
    this.loadSuppliers();
    this.loadPurchaseOrders();
  }

  loadPurchaseOrders(): void {
    this.purchaseOrderService.getAllPurchaseOrders().subscribe({
      next: (order) => {
        this.purchaseOrders = order;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  loadSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe((suppliers) => {
      suppliers.forEach((supplier) => {
        this.suppliersMap.set(supplier.id, supplier.supplierName);
      });
    });
  }
  getSupplierName(supplierId: string): string {
    return this.suppliersMap.get(supplierId) || 'Supplier Not Found';
  }

  deleteFn(id: string) {
    this.purchaseOrderService.deletePurchaseOrder(id).subscribe({
      next: (response) => {
        alert(response.poNumber + 'is deleted successfully!');
        this.ngOnInit();
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

 
}
