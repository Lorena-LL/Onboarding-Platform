export type TaskStatus = "Active" | "Completed";

export interface AssignedOnboardingTaskDto {
  id: string;
  taskId: string;
  taskName: string;
  taskCategory: string;
  taskDescription: string;
  userId: string;
  assignedAt: string;
  dueAt: string;
  completedAt: string | null;
  status: TaskStatus;
}