export interface PlatformList {
    Id: number;
    Platform: string;
    GameCount: number;
}

export interface PlatformAdd {
    Name: string;
}

export interface PlatformEdit {
    PlatformId: number;
    Name: string;
    URLToDocumentation: string;
}

export interface Platform {
    PlatformId: number;
    Name: string;
    URLToDocumentation: string;
    CreatedAt: string;
    UpdatedAt: string;
    Games: PlatformGames[];
    Accounts: PlatformAccounts[];
}

export interface PlatformGames {
    Id: number;
    Name: string;
}

export interface PlatformAccounts {
    Id: number;
    Username: string;
}

export interface Platforms {
    Id: number;
    Platform: string;
}
  