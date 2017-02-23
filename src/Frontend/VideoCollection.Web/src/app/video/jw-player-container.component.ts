import {
    Component,
    EventEmitter,
    Input,
    Output,
    ElementRef,
    AfterViewInit,
    OnDestroy
} from "@angular/core";

import { guid } from "../utilities";

declare var jwplayer: any;

@Component({
    template: require("./jw-player-container.component.html"),
    styles: [require("./jw-player-container.component.scss")],
    selector: "jw-player-container"
})
export class JwPlayerContainerComponent implements AfterViewInit { 
    constructor(private _elementRef: ElementRef) { }

    private _playerInstance: any = null;

    @Input()
    public title: string;

    @Input()
    public file: string;

    @Input()
    public height: string;

    @Input()
    public width: string;

    public get playerInstance(): any {
        if (!this._playerInstance) {
            this._playerInstance = jwplayer(this._elementRef.nativeElement);
        }
        return this._playerInstance;
    }

    ngAfterViewInit() {
        this.playerInstance.setup({
            file: this.file,
            height: this.height,
            width: this.width
        });
    }

    public uniqueId: string = guid();
}
