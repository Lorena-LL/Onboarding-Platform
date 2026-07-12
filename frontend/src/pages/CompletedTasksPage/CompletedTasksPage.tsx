import { useEffect, useState } from "react";
import { Badge, CircularProgress, Stack, Typography } from "@mui/material";
import CheckCircleOutlined from "@mui/icons-material/CheckCircleOutlined";
import TaskCard from "../../components/TaskCard/TaskCard";
import { getCompletedAssignedTasks } from "../../services/taskService";
import { getUserId } from "../../utils/session";
import { GENERAL_ERROR } from "../../constants/errors";
import { COMPLETED_TASKS_PAGE } from "../../constants/messages";
import type { AssignedOnboardingTaskDto } from "../../models/task.types";
import "./CompletedTasksPage.css";

const CompletedTasksPage: React.FC = () => {
    const [tasks, setTasks] = useState<AssignedOnboardingTaskDto[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    useEffect(() => {
        const fetchCompletedTasks = async (): Promise<void> => {
            const userId = getUserId();
            if (!userId) {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
                setIsLoading(false);
                return;
            }
            try {
                const completedTasks = await getCompletedAssignedTasks(userId);
                setTasks(completedTasks);
            } catch {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
            } finally {
                setIsLoading(false);
            }
        };

        fetchCompletedTasks();
    }, []);

    return (
        <div className="completed-tasks-page">
            <Stack className="completed-tasks-page_header">
                <Typography variant="h5" className="completed-tasks-page__title">
                    {COMPLETED_TASKS_PAGE.title}
                </Typography>
                <Badge badgeContent={tasks.length} color="success">
                    <CheckCircleOutlined />
                </Badge>
            </Stack>

            {isLoading && <CircularProgress size={28} className="completed-tasks-page__spinner" />}
            {!isLoading && errorMessage && (
                <Typography variant="body2" color="error">{errorMessage}</Typography>
            )}
            {!isLoading && !errorMessage && (
                <Stack spacing={2} className="completed-tasks-page__list">
                    {tasks.map((task) => (
                        <TaskCard key={task.id} task={task} />
                    ))}
                </Stack>
            )}
        </div>
    );
};

export default CompletedTasksPage;