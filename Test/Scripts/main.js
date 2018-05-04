(function ($) {
    $.fn.main = function (settings) {

        return this.each(function () {
            var container = $(this);            

            container.find('#showResultsForFirstTest').click(function () {
                var self = $(this);

                var categoryIdText = container.find('#categoryIdTextBox').val();

                var categoryId = parseInt(categoryIdText);

                if (isNaN(categoryId)) {
                    alert('Wrong or missed category ID');
                }

                $.get(settings.getCategoryUrl, { categoryId: categoryId }, function (response) {
                    var str = '';
                    str += "<b>Category ID:</b> " + response.CategoryId + "<br />";
                    str += "<b>Parent Category ID:</b> " + response.ParentCategoryId + "<br />";
                    str += "<b>Name:</b> " + response.Name + "<br />";
                    str += "<b>Keywords:</b> " + response.Keywords ;

                    container.find('#results').html(str);
                });                
            });

            container.find('#showResultsForSecondTest').click(function () {
                var self = $(this);

                var levelText = container.find('#levelDepthTextBox').val();

                var level = parseInt(levelText);

                if (isNaN(level)) {
                    alert('Wrong or missed level depth');
                }

                $.get(settings.getCategoryIdsByLevelUrl, { level: level }, function (response) {
                    container.find('#results').text('');

                    for (var i = 0; i < response.length; i++) {
                        container.find('#results').append(response[i]);
                        container.find('#results').append('<br />');
                    }
                });
            });
        });
    };
})(jQuery);