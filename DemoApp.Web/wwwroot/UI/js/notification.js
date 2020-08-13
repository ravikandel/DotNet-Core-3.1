function ManageMessage(code, msg) {
    switch (code) {
        case 0:
            Success(msg);
            break;
        case 1:
            Fail(msg);
            break;
        case 2:
            Info(msg);
            break;
        default:
            Warning(msg);
    }
}



function Success(msg) {
    iziToast.success({
        title: 'Success',
        message: msg,
        icon: 'mdi mdi-checkbox-multiple-marked-circle',
        position: 'topRight',
        animateInside: true,
        transitionIn: 'fadeInDown',
        titleColor: '#FFF',
        messageColor: '#FFF',
        backgroundColor: '#4CAF50',
        iconColor: "#F9F9F9",
        timeout: 2000
    });
}


function Info(msg) {
    iziToast.info({
        title: 'Info',
        message: msg,
        icon: 'mdi mdi-checkbox-multiple-marked-circle',
        position: 'topRight',
        animateInside: true,
        transitionIn: 'fadeInDown',
        titleColor: '#FFF',
        messageColor: '#FFF',
        backgroundColor: '#2196F3',
        iconColor: "#F9F9F9",
        timeout: 2000
    });
}


function Warning(msg) {
    iziToast.warning({
        title: 'Warning',
        message: msg,
        icon: 'mdi mdi-close-octagon-outline',
        position: 'topRight',
        animateInside: true,
        transitionIn: 'fadeInDown',
        titleColor: '#FFF',
        messageColor: '#FFF',
        backgroundColor: '#FFAB00',
        iconColor: "#F9F9F9",
        timeout: 2000
    });
}


function Fail(msg) {
    iziToast.info({
        title: 'Error',
        message: msg,
        icon: 'mdi mdi-close-octagon-outline',
        position: 'topRight',
        animateInside: true,
        transitionIn: 'fadeInDown',
        titleColor: '#FFF',
        messageColor: '#FFF',
        backgroundColor: '#F44336',
        iconColor: "#F9F9F9",
        timeout: 2000
    });
}
