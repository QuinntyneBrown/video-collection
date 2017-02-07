import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { DigitalAssetService } from './digital-asset.service';
import { DigitalAssetListItemComponent } from './digital-asset-list-item.component';

const declarables = [DigitalAssetListItemComponent];
const providers = [DigitalAssetService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class DigitalAssetModule { }
