import { Routes, RouterModule } from '@angular/router';

import { AuthGuardService, LoginPageComponent } from "./core";

import { DigitalAssetListPageComponent, DigitalAssetEditPageComponent } from "./digital-assets";

export const routes: Routes = [
    {
        path: '',
        component: DigitalAssetListPageComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: "login",
        component: LoginPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    LoginPageComponent,
    DigitalAssetListPageComponent
];