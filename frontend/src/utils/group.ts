import type { TeamMemberDto } from "../models/team.types";

export const groupTeamMembers = (
    items: TeamMemberDto[], 
    getKey: (item: TeamMemberDto) => string
): Record<string, TeamMemberDto[]> => {

    const groups: Record<string, TeamMemberDto[]> = {};

    for (const item of items) {
        const key = getKey(item);

        if (!groups[key]) {
            groups[key] = [];
        }

        groups[key].push(item);
    }

    return groups;
};