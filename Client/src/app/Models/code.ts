export interface CodeList {
  Id: number;
  Code: string;
  Used: boolean;
  Account: string;
  Game: string;
}

export interface CodeAdd {
  CodeString: string,
  UsedStatus: boolean;
  EmailAccountId: null;
  PlatformId: number;
  GameId: number;
}

export interface CodeEdit {
  CodeId: number;
  CodeString: string;
  UsedStatus: boolean;
  EmailAccountId: number;
  PlatformId: number;
  AccountId: number;
  // Account: string;
  GameId: number;
}

export interface Code {
  CodeId: number;
  CodeString: string;
  AccountId: number;
  Account: string;
  UsedStatus: boolean;
  EmailAccountId: number;
  PlatformId: number;
  GameId: number;
  Game: string;
}
