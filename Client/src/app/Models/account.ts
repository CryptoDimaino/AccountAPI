export interface AccountList {
    Id: number;
    Username: string;
    Password: string;
    Email: string;
    EmailPassword: string;
    Platform: string;
    Event: string;
}

export interface AccountAdd {
    Username: string;
    Password: string;
    EmailAccountId: number;
    PlatformId: number;
}

export interface AccountEdit {
    AccountId: number;
    Username: string;
    Password: string;
    EmailAccountId: number;
    PlatformId: number;
    Status: boolean;
    EventId: number;
}

export interface Account {
    AccountId: number;
    Username: string;
    Password: string;
    Email: string;
    EmailPassword: string;
    EmailAccountId: number;
    Status: boolean;
    PlatformId: number;
    Platform: string;
    EventId: number;
    Event: string;
    Codes: AccountCodes[];
}

export interface AccountCodes {
    CodeId: number;
    Code: string;
}

export interface AccountPlatform {
    PlatformId: number;
    EmailAccountId: number;
}
