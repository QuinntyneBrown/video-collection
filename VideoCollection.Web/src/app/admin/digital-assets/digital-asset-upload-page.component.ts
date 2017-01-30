import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { DigitalAssetService } from "./digital-asset.service";

@Component({
    template: require("./digital-asset-upload-page.component.html"),
    styles: [require("./digital-asset-upload-page.component.scss")],
    selector: "digital-asset-upload-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetUploadPageComponent implements OnInit { 

    constructor(private _digitalAssetService: DigitalAssetService) {

    }

    ngOnInit() {

    }


    public tryToUpload($event: any) {
        this._digitalAssetService.upload({ data: $event.files })
            .subscribe(x => {

            });
    }
}
