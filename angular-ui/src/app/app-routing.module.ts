import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SupplierListComponent } from './components/supplier/supplier-list/supplier-list.component';
import { authGuard } from './guards/auth.guard';
import { AddSupplierComponent } from './components/supplier/add-supplier/add-supplier.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { AddProductComponent } from './components/product/add-product/add-product.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PurchaseOrderListComponent } from './components/purchase/purchase-order-list/purchase-order-list.component';
import { AddPurchaseOrderComponent } from './components/purchase/add-purchase-order/add-purchase-order.component';


const routes: Routes = [
 
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: '', component: DashboardComponent, canActivate: [authGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [authGuard] },
  {
    path: 'supplierlist',
    component: SupplierListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'supplier/add',
    component: AddSupplierComponent,
    canActivate: [authGuard],
  },
  {
    path: 'supplier/edit/:id',
    component: AddSupplierComponent,
    canActivate: [authGuard],
  },
  {
    path: 'productlist',
    component: ProductListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'product/add',
    component: AddProductComponent,
    canActivate: [authGuard],
  },
  {
    path: 'product/edit/:id',
    component: AddProductComponent,
    canActivate: [authGuard],
  },
  {
    path: 'purchaseorderlist',
    component: PurchaseOrderListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'purchaseorder/add',
    component: AddPurchaseOrderComponent,
    canActivate: [authGuard],
  },

  {
    path: 'purchaseorder/edit/:id',       
    component: AddPurchaseOrderComponent,
    canActivate: [authGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
