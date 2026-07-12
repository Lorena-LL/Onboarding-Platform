import { useEffect, useState } from "react";
import { Badge, CircularProgress, Stack, Typography } from "@mui/material";
import AssignmentOutlinedIcon from "@mui/icons-material/AssignmentOutlined";
import TaskCard from "../../components/TaskCard/TaskCard";
import { getActiveAssignedTasks } from "../../services/taskService";
import { getUserId } from "../../utils/session";
import { GENERAL_ERROR } from "../../constants/errors";
import { ACTIVE_TASKS_PAGE } from "../../constants/messages";
import type { AssignedOnboardingTaskDto } from "../../models/task.types";
import "./ActiveTasksPage.css";

const ActiveTasksPage: React.FC = () => {
    const [tasks, setTasks] = useState<AssignedOnboardingTaskDto[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);

    useEffect(() => {
        const fetchActiveTasks = async (): Promise<void> => {
            const userId = getUserId();
            if (!userId) {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
                setIsLoading(false);
                return;
            }
            try {
                const allTasks = await getActiveAssignedTasks(userId);
                setTasks(allTasks.filter((task) => task.status === "Active"));
            } catch {
                setErrorMessage(GENERAL_ERROR.somethingWentWrong);
            } finally {
                setIsLoading(false);
            }
        };

        fetchActiveTasks();
    }, []);

    return (
        <div className="active-tasks-page">
            <Stack className="active-tasks-page__header">
                <Typography variant="h5" className="active-tasks-page__title">
                    {ACTIVE_TASKS_PAGE.title}
                </Typography>
                <Badge badgeContent={tasks.length} color="primary">
                    <AssignmentOutlinedIcon />
                </Badge>
            </Stack>

            {isLoading && <CircularProgress size={28} className="active-tasks-page__spinner" />}
            {!isLoading && errorMessage && (
                <Typography variant="body2" color="error">{errorMessage}</Typography>
            )}
            {!isLoading && !errorMessage && (
                <Stack spacing={2} className="active-tasks-page__list">
                    {tasks.map((task) => (
                        <TaskCard key={task.id} task={task} />
                    ))}
                </Stack>
            )}
        </div>
    );
};

export default ActiveTasksPage;