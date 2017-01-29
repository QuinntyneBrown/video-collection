import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./digital-asset-upload-page.component.html"),
    styles: [require("./digital-asset-upload-page.component.scss")],
    selector: "digital-asset-upload-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetUploadPageComponent implements OnInit { 
    ngOnInit() {

    }
}
