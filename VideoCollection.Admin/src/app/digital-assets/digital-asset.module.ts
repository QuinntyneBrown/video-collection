import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { DigitalAssetService } from './digital-asset.service';

const declarables = [];
const providers = [DigitalAssetService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class DigitalAssetModule { }
