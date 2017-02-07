import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { DigitalAssetUploadComponent } from './digital-asset-upload.component';

const declarables = [DigitalAssetUploadComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class SharedModule { }
