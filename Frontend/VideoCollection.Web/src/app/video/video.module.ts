import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { JwPlayerComponent } from './jw-player-handler.component';

const declarables = [JwPlayerComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class VideoModule { }
