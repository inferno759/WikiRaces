import { PathStep } from './pathStep';
import { User } from './user';

export interface LeaderboardLine {
    id: number;
    raceId: number;
    userId: number;
    score: number;
    timeElapsed: number;
    stepsTaken: number;
    leaderboardDateTime: string;
    path: PathStep[];
    user: User;
  }