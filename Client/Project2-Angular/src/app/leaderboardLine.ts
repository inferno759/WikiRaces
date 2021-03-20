import { PathStep } from './pathStep';

export interface LeaderboardLine {
    id: number;
    raceId: number;
    userId: number;
    score: number;
    timeElapsed: number;
    stepsTaken: number;
    leaderboardDateTime: string;
    path: PathStep[];
  }