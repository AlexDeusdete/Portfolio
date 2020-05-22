
var idSocialCliked = " ";

$(document).ready(function () {
    $('#phone').mask('(99) 99999-9999');
    $('#InitialDate').mask('00/00/0000');
    $('#EndDate').mask('00/00/0000');

    $('#FCP').farbtastic('#FristColorHex');
    $('#SCP').farbtastic('#SecondColorHex');
});

var UploadImage = function (e) {
    var file = e.target.files[0];

    var reader = new FileReader;

    reader.readAsDataURL(file);
    reader.onload = function (_file) {
        $("#imgFoto").attr('src', _file.target.result);
    }


};

function SaveImgCapa() {
    var id = $("#ID").val();

    var file = $("#imgCapa").get(0).files[0];
    var formData = new FormData();
    formData.set("file", file, file.name);
    formData.set("portfolioID", id);

    var url = "/Portfolios/InsertImage";
    $.ajax({
        url: url,
        method: "post",
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    })
        .then(function (result) {
            var divSM = $("#PortfolioImages");
            divSM.empty();
            divSM.html(result);
        });
}

function DelimgCapa(e) {
    var Pid = $("#ID").val();
    var url = "/Portfolios/DeleteImageCapa";
    $.ajax({
        url: url,
        method: "post",
        data: { type: "capa", id: e, idComponent: Pid }
    })
        .then(function (result) {
            var divSM = $("#PortfolioImages");
            divSM.empty();
            divSM.html(result);
        });
}

function EditEducation(e) {
    var url = "/Portfolios/EditEducation";

    $.ajax({
        url: url,
        data: { id: e },
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data.id > 0) {
                $("#id").val(data.id);
                $("#Institution").val(data.institution);
                $("#CourseName").val(data.courseName);
                $("#InitialDate").val(data.initialDate.substring(8, 10) + "/" + data.initialDate.substring(5, 7) + "/" + data.initialDate.substring(0, 4));
                $("#EndDate").val(data.endDate.substring(8, 10) + "/" + data.endDate.substring(5, 7) + "/" + data.endDate.substring(0, 4));
                $("#CertificateCode").val(data.certificateCode);
                $("#CertificateUrl").val(data.certificateUrl);    
            }
        }
    });
}

function ClearEducation() {
    $("#id").val('');
    $("#Institution").val('');
    $("#CourseName").val('');
    $("#InitialDate").val('');
    $("#EndDate").val('');
    $("#CertificateCode").val('');
    $("#CertificateUrl").val('');
}

function SaveEducation() {
    var personid = $("#PersonID").val();
    var id = $("#id").val();
    var institution = $("#Institution").val();
    var courseName = $("#CourseName").val();
    var initialDate = $("#InitialDate").val();
    var endDate = $("#EndDate").val();
    var certificateCode = $("#CertificateCode").val();
    var certificateUrl = $("#CertificateUrl").val();

    var url = "/Portfolios/SaveEducation";

    $.ajax({
        url: url,
        data: { id: id, personID: personid, institution: institution, courseName: courseName, initialDate: initialDate, endDate: endDate, certificateCode: certificateCode, certificateUrl: certificateUrl },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.result > 0) {
                LoadEducation()
            }
        }

    });

    idSocialCliked = " ";
}

function LoadEducation() {    
    var personid = $("#PersonID").val();

    var url = "/Portfolios/LoadEducation";

    $.ajax({
        url: url,
        data: { personID: personid },
        type: "GET",
        dataType: "html",
        success: function (data) {
            $('#education').modal('hide');

            $('#education').on('hidden.bs.modal', function (e) {
                var divSM = $("#educations");
                divSM.empty();
                divSM.html(data);
            })

        }
    });
}

function LoadSocialMedia() {
    var personid = $("#PersonID").val();

    var url = "/Portfolios/LoadSocialMedia";

    $.ajax({
        url: url,
        data:{ personID: personid },
        type: "GET",
        dataType: "html",
        success: function (data) {
            $('#socialMedia').modal('hide');

            $('#socialMedia').on('hidden.bs.modal', function (e) {
                var divSM = $("#socialMedias");
                divSM.empty();
                divSM.html(data);
            })

        }
    });
}

function SaveSocialMedia() {
    var username = $("#UserName").val();
    var accesslink = $("#AccessLink").val();
    var personid = $("#PersonID").val();

    var url = "/Portfolios/SaveSocialMedia";

    $.ajax({
        url: url,
        data: { personID: personid, socialMedia: idSocialCliked, userName: username, accessLink: accesslink },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.result > 0) {
                LoadSocialMedia()
            }
        }

    });

    idSocialCliked = " ";
};

function SetSocialMedia(e) {
    idSocialCliked = e;
};

function CreateProject() {
    var id = $("#ID").val();
    var projectName = $("#projectName").val();

    var url = "/Portfolios/CreateProject";
    $.ajax({
        url: url,
        method: "post",
        data: { name: projectName, portfolioID: id},
    })
        .then(function (result) {
            var divSM = $("#projects");
            divSM.empty();
            divSM.html(result);
        });
}

function DeleteProject(e) {
    var pid = $("#ID").val();
    var id = e;

    var url = "/Portfolios/DeleteProject";
    $.ajax({
        url: url,
        method: "post",
        data: { id: id, portfolioID: pid },
    })
        .then(function (result) {
            var divSM = $("#projects");
            divSM.empty();
            divSM.html(result);
        });
}

function EditProject(e) {
    var url = "/Portfolios/EditProject";
    $.ajax({
        url: url,
        data: { id: e },
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data.id > 0) {
                $("#idProject").val(data.id);
                $("#Name").val(data.name);
                $("#GitHubProject").val(data.gitHub);
                $("#DateCriation").val(data.dateCriation.substring(8, 10) + "/" + data.dateCriation.substring(5, 7) + "/" + data.dateCriation.substring(0, 4));
                $("#Language").val(data.language);
                $("#DescriptionProject").val(data.description);
            }
        }
    });

    var url = "/Portfolios/LoadProjectImage";

    $.ajax({
        url: url,
        data: { portfolio_ProjectsID: e },
        type: "GET",
        dataType: "html",
        success: function (data) {
            debugger;
            var divSM = $("#projectImage");
                divSM.empty();
                divSM.html(data);
        }
    });
}

function SaveImgProject() {
    var id = $("#idProject").val();

    var file = $("#imgProject").get(0).files[0];
    var formData = new FormData();
    formData.set("file", file, file.name);
    formData.set("portfolio_ProjectsID", id);

    var url = "/Portfolios/InsertImageProject";
    $.ajax({
        url: url,
        method: "post",
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    })
        .then(function (result) {
            var divSM = $("#projectImage");
            divSM.empty();
            divSM.html(result);
        });
}

function DelimgProject(e) {
    var Pid = $("#idProject").val();
    var url = "/Portfolios/DeleteImageCapa";
    $.ajax({
        url: url,
        method: "post",
        data: { type: "project", id: e, idComponent: Pid }
    })
        .then(function (result) {
            var divSM = $("#projectImage");
            divSM.empty();
            divSM.html(result);
        });
}

function SaveProject() {
    var portfolioID = $("#ID").val();
    var id = $("#idProject").val();
    var name = $("#Name").val();
    var gitHub = $("#GitHubProject").val();
    var description = $("#DescriptionProject").val();
    var language = $("#Language").val();
    var dateCriation = $("#DateCriation").val();

    var url = "/Portfolios/SaveProject";

    $.ajax({
        url: url,
        data: { ID: id, PortfolioID: portfolioID, Name: name, GitHub: gitHub, Description: description, Language: language, DateCriation: dateCriation},
        type: "PUT",
        dataType: "html"
    }).then(function (result) {
        $('#project').modal('hide');

        $('#project').on('hidden.bs.modal', function (e) {
            var divSM = $("#projects");
            divSM.empty();
            divSM.html(result);
        })
    });

    idSocialCliked = " ";
}
