export interface GameList {
    Id: number;
    Name: string;
    Platform: string;
    NumberOfAccounts: number;
}

export interface GameAdd {
    Name: string;
    PlatformId: number;
}

export interface GameEdit {
    GameId: number;
    Name: string;
    PlatformId: string;
    URLToDocumentation: string;
    ReleaseDate: Date;
}

export interface Game {
    GameId: number;
    Title: string;
    Platform: string;
    ReleaseDate: string;
    URLToDocumentation: string;
    Accounts: GameAccount[];
}

export interface GameAccount {
    CodeId: number;
    Id: number;
    Code: string;
    Username: string;
    Password: string;
    Email: string;
    EmailPassword: string;
}
