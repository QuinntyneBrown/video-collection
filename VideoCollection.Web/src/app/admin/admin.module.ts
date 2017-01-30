import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { DigitalAssetModule } from "./digital-assets";
import { VideoModule  } from "./videos";

const declarables = [];
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
