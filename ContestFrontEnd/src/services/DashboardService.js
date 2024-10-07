const DashboardService = () => {
    const port = 44314;
    const GetUserRating = async (id) => {
        try {
            const params = new URLSearchParams({ id: id });
            const response = await fetch(`https://localhost:${port}/api/userrating/getuserrating?${params}`, {
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
            return -1; // Ba�ar�s�zl�k durumunu d�nd�r
        }
    }
    const GetUserAwards = async (id) => {
        try {
            const params = new URLSearchParams({ id: id });
            const response = await fetch(`https://localhost:${port}/api/useraward/getuserawards?${params}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                debugger;
                throw new Error('Cannot retrieve user awards');
            }
            const data = await response.json();
            console.log(data);
            return data.data;

        } catch (err) {
            console.error(err);
            return -1; // Ba�ar�s�zl�k durumunu d�nd�r
        }
    }
    const GetUserRank = async (id) => {
        try {
            const params = new URLSearchParams({ id: id });
            const response = await fetch(`https://localhost:${port}/api/userrank/getuserrank?${params}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                debugger;
                throw new Error('Cannot retrieve user rank');
            }
            const data = await response.json();
            console.log(data);
            return data.data;

        } catch (err) {
            console.error(err);
            return -1; // Ba�ar�s�zl�k durumunu d�nd�r
        }
    }
    return { GetUserRating, GetUserRank,GetUserAwards}
}

export default DashboardService