import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { VideoService } from './video.service';

const declarables = [];
const providers = [VideoService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class VideoModule { }
