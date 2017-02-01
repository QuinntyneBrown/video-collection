import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";   
import { DigitalAssetService } from "./digital-asset.service";
import { DigitalAsset } from "./digital-asset.model";

@Component({
    template: require("./digital-asset-list-page.component.html"),
    styles: [require("./digital-asset-list-page.component.scss")],
    selector: "digital-asset-list-page"
})
export class DigitalAssetListPageComponent implements OnInit {
    constructor(
        private _digitalAssetService: DigitalAssetService,
        private _router: Router
    ) { }

    ngOnInit() {
        this._digitalAssetService
            .get()
            .subscribe((response: any) => {                
                this.digitalAssets = response.digitalAssets;
            });
    }    

    public digitalAssets: Array<DigitalAsset> = [];
}
