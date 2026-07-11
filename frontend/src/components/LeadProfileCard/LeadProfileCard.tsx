import { Avatar, Card, CardContent, Stack, Typography } from "@mui/material";
import { EmailOutlined } from "@mui/icons-material";
import { getInitials } from "../../utils/name";
import { LEAD_CARD } from "../../constants/messages";
import type { LeadProfileCardProps } from "./LeadProfileCard.types";
import type { TeamMemberDto } from "../../models/team.types";
import "./LeadProfileCard.css";

const LeadProfileCard: React.FC<LeadProfileCardProps> = ({ leads }: LeadProfileCardProps) => {
    return (
        <Card variant="outlined" className="lead-profile-card">
            <CardContent>
                <Typography variant="subtitle1" className="lead-profile-card__title">
                    {LEAD_CARD.title}
                </Typography>

                <Stack spacing={2}>
                    {leads.map((lead: TeamMemberDto) => {
                        const initials: string = getInitials(lead.firstName, lead.lastName);

                        return (
                        <>
                            <Stack direction="row" spacing={2} className="lead-profile-card__person">
                                <Avatar className="lead-profile-card__avatar">{initials}</Avatar>
                                <div>
                                    <Typography variant="body1" className="lead-profile-card__name">
                                        {lead.firstName} {lead.lastName}
                                    </Typography>
                                    <Typography variant="body2" className="lead-profile-card__role">
                                        {lead.role} · {LEAD_CARD.leads} the {lead.teamName} team
                                    </Typography>
                                </div>
                            </Stack>

                            <Stack direction="row" spacing={1} className="lead-profile-card__email">
                                <EmailOutlined fontSize="small" />
                                <Typography variant="body2">{lead.email}</Typography>
                            </Stack>
                        </>);
                    })}
                </Stack>
            </CardContent>
        </Card>
    );
};

export default LeadProfileCard;