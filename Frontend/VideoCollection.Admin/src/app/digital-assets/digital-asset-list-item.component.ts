import { Component, ChangeDetectionStrategy, Input, OnInit, EventEmitter, Output } from "@angular/core";
import { DigitalAsset } from "./digital-asset.model";
import { DigitalAssetService } from "./digital-asset.service";
import { Router } from "@angular/router";

@Component({
    template: require("./digital-asset-list-item.component.html"),
    styles: [require("./digital-asset-list-item.component.scss")],
    selector: "digital-asset-list-item"
})
export class DigitalAssetListItemComponent {
    constructor(
        private _digitalAssetService: DigitalAssetService,
        private _router: Router
    ) {

    }
    
    @Input()
    public set digitalAsset(value: DigitalAsset) { this._digitalAsset = value; }

    public get digitalAsset():DigitalAsset { return this._digitalAsset; }

    private _digitalAsset: DigitalAsset = <DigitalAsset>{};

    public onEdit() {
        this._router.navigate(["digitalasset","edit",this.digitalAsset.id])
    }

    @Output()
    onDeleted = new EventEmitter();

    public onDelete() {
        this.onDeleted.emit({
            digitalAssetId: this.digitalAsset.id
        });
    }
}
