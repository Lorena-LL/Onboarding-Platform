export const formatJoinedDate = (isoDate: string): string =>
    new Date(isoDate).toLocaleDateString("en-US", {
        year: "numeric",
        month: "long",
        day: "numeric",
    });