const CompetitionService = () => {
    const port = 44313;
    const GetAllCompetitions = async (id) => {
        try {
            const response = await fetch(`https://localhost:${port}/api/competition/getall`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                debugger;
                throw new Error('Cannot retrieve user rating');
            }
            const data = await response.json();
            console.log(data);
            return data.data;

        } catch (err) {
            console.error(err);
            return -1; // Baþarýsýzlýk durumunu döndür
        }
    }
    return { GetAllCompetitions }
}

export default CompetitionService