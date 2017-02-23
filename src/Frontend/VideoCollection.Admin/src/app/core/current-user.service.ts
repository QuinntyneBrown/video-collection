﻿import { Injectable } from "@angular/core";
import { Storage } from "../utilities";
import { AuthService } from "./auth.service";
import { Observable } from "rxjs";
import { ExceptionService } from "../core";

@Injectable()
export class CurrentUserService {
    constructor(
        private _authService: AuthService,
        private _storage: Storage
    ) {  }

    public get token() { return this._storage.get({ name: "accessToken" }); }

    public getCurrentUser(): Observable<boolean> {
        return this._authService
            .getCurrentUser()
            .map((response: boolean | {username:string}) => {       
                const isLoggedIn = response != false;
                if (isLoggedIn) {
                    this.username = (<{ username: string }>response).username;
                }                                        
                return isLoggedIn;
            });
    }

    public username: string;
}