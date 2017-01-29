import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { ApiService } from "../shared";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
    selector: "login-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
    constructor(
        private _apiService: ApiService
    ) { }

    public tryToLogin($event: { value: { username: string, password: string } }) {

    }
}
