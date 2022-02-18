class MateriSubmit {

    public materi() {
        try {
            const MateriTitleValue = this.getInputValue('MateriTitle')
            const MateriDescriptionValue = this.getInputValue('MateriDescription')
            const CreatedByValue = this.getInputValue('CreatedBy')
            const RemarksValue = this.getInputValue('Remarks')

            this.InvokeAPI(
                {
                    'MateriTitle': MateriTitleValue,
                    'MateriDescription': MateriDescriptionValue,
                    'CreatedBy': CreatedByValue,
                    'Remarks': RemarksValue
                });
        }
        catch (e) {
            window.alert(e.message);
        }
    }

    private successAlert() {
        window.alert('Materi berhasil Ditambakhan')
    }

    InvokeAPI(data: any) {
        try {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', 'https://localhost:44338/api/Materi/');
            xhr.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');
            xhr.send(JSON.stringify({
                'materiTitle': 'data 1',
                'materiDescription': 'data 1 satu',
                'createdBy': 'created',
                'remarks': 'kampus'
            }));
            xhr.onload = this.successAlert;
        }
        catch (e) {
            window.alert(e.message);
        }
    }

    private getInputValue(controlName: string) {
        return (document.getElementById(controlName) as HTMLInputElement).value;
    }
}

function SaveMateri() {

    try {
        const u: MateriSubmit = new MateriSubmit();
        u.materi();
    }
    catch (e) {
        window.alert(e.message);
    }

    return false;
}