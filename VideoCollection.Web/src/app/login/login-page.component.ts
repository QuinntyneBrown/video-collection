import {
    Component,
    ChangeDetectionStrategy,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    Renderer,
    ElementRef
} from "@angular/core";

import {
    FormGroup,
    FormControl,
    Validators    
} from "@angular/forms";
import { ApiService } from "../shared";

import { LoginRedirectService } from "../shared";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
    selector: "login-page"
})
export class LoginPageComponent implements AfterViewInit {
    constructor(
        private _apiService: ApiService,
        private _loginRedirectService: LoginRedirectService,
        private _renderer: Renderer,
        private _elementRef: ElementRef
    ) { }

    public form = new FormGroup({
        username: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required])
    });

    public get username(): HTMLElement {
        return this._elementRef.nativeElement.querySelector("#username");
    }

    ngAfterViewInit() {
        this._renderer.invokeElementMethod(this.username, 'focus', []);
        this.form.patchValue({ "username": "quinntynebrown@gmail.com" });
        this.form.patchValue({ "password": "P@ssw0rd" });
    }

    public tryToLogin() {
        this._apiService.tryToLogin({
            username: this.form.value.username,
            password: this.form.value.password
        }).subscribe(x => {
            this._loginRedirectService.redirectPreLogin();
        });        
    }
}
