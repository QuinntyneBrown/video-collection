import { environment } from "../environment";
import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";
import { Observable } from "rxjs";
import { Storage, formEncode, OAuthHelper } from "../utilities"

@Injectable()
export class AuthService {
    constructor(
        private _http: Http,
        private _oauthHelper: OAuthHelper,
        private _storage: Storage
    ) { }

    public tryToLogin(options: { username: string, password: string }) {
        Object.assign(options, { grant_type: "password" });
        let headers = new Headers();
        headers.append("Content-Type", "application/x-www-form-urlencoded");
        return this._http
            .post(`${this._baseUrl}/api/user/token`, formEncode(options), { headers: headers })
            .map(response => {
                var accessToken = response.json()["access_token"];
                this._storage.put({
                    name: "accessToken", value: accessToken
                });
                return accessToken;
            })
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getCurrentUser() {
        return this._http
            .get(`/api/user/current`, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}
