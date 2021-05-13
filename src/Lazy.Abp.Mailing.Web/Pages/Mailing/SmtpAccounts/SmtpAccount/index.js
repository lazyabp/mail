$(function () {

    var l = abp.localization.getResource('Mailing');

    var service = trait.abp.mailing.smtpAccounts.smtpAccount;
    var createModal = new abp.ModalManager(abp.appPath + 'Mailing/SmtpAccounts/SmtpAccount/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Mailing/SmtpAccounts/SmtpAccount/EditModal');

    var dataTable = $('#SmtpAccountTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('SmtpAccountDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('SmtpAccountHost'),
                data: "host"
            },
            {
                title: l('SmtpAccountPort'),
                data: "port"
            },
            {
                title: l('SmtpAccountAccount'),
                data: "account"
            },
            {
                title: l('SmtpAccountPassword'),
                data: "password"
            },
            {
                title: l('SmtpAccountEnableSsl'),
                data: "enableSsl"
            },
            {
                title: l('SmtpAccountPower'),
                data: "power"
            },
            {
                title: l('SmtpAccountSenderEmail'),
                data: "senderEmail"
            },
            {
                title: l('SmtpAccountSenderName'),
                data: "senderName"
            },
            {
                title: l('SmtpAccountIsActive'),
                data: "isActive"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSmtpAccountButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
