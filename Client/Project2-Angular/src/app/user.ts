export interface User {
    id: number;
    username: string;
    password: string;
    friendlist: Array<number>;

    // okta auth0 may invalidate/replace password features
  }

