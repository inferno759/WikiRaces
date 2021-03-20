export interface User {
    id: number;
    username: string;
    password: string;
    friends: Array<number>;

    // okta auth0 may invalidate/replace password features
  }

