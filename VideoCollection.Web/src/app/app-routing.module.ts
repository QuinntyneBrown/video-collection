import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from "./landing";
import { AdminPageComponent } from "./admin";


export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'admin',
        component: AdminPageComponent,
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    AdminPageComponent,
    LandingPageComponent
];