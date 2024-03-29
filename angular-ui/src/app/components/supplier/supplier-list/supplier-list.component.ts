import { Component, OnInit } from '@angular/core';
import { Supplier } from '../../../models/supplier.model';
import { SupplierService } from '../../../services/supplier.service';

@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrl: './supplier-list.component.css',
})
export class SupplierListComponent implements OnInit {
  suppliers: Supplier[] = [];

  constructor(private supplierService: SupplierService) {}

  ngOnInit(): void {
    this.loadSupplier();
  }

  loadSupplier(): void {
    this.supplierService.getAllSuppliers().subscribe({
      next: (supplier) => {
        this.suppliers = supplier;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  deleteFn(id: string) {
    this.supplierService.deleteSupplier(id).subscribe({
      next: (response) => {
        alert(response.supplierName + ' is deleted successfully!');
        this.ngOnInit();
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  createImagePath(serverPath: string) {
    return this.supplierService.getImageFullPath(serverPath);
  }
}
