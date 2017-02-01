import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { DigitalAssetModule } from "./digital-assets";
import { VideoModule  } from "./videos";
import { AdminHeaderComponent } from "./admin-header.component";

const declarables = [
    AdminHeaderComponent
];

const providers = [];

@NgModule({
    imports: [
        CommonModule,
        DigitalAssetModule,
        VideoModule
    ],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class AdminModule { }
