
//validate manager user form
$(function () {
	$("form[name='createUser']").validate({
		rules: {
			Email: {
				required: true,
				email: true,
				remote: {
					url: "VerifyEmail",
					type: "post",
				}
			},
			Username: {
				required: true,
				minlength: 5,
				maxlength: 20,
				remote: {
					url: "VerifyUsername",
					type: "post",
				}
			},
			Password: {
				required: true,
				minlength: 8,
			},
			Confirm: {
				required: true,
				minlength: 8,
				equalTo: "#Password",
			}
		}
	});
});





