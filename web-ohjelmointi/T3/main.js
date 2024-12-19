$(function () {
    var canvas = $('#myCanvas')[0],
        c = canvas.getContext('2d'),
        expr = '',
        min = 0,
        max = 10,
        step = 1,
        scale = 1,
        tree,
        yMin = 0,
        yMax = 0;

    initControls();
    initTextField();

    function initControls() {
        $('#calculate').click(function (event) {
            event.preventDefault();

            expr = $('#function').val();
            min = parseFloat($('#min').val());
            max = parseFloat($('#max').val());
            step = parseFloat($('#step').val());
            scale = parseFloat($('#scale').val());

            if (!expr || isNaN(min) || isNaN(max) || isNaN(step) || isNaN(scale)) {
                alert('Please fill in all fields.');
                return;
            }

            try {
                tree = math.compile(expr);
                var values = getValues();
                calculateYRange(values);
                displayValues(values);
                drawCurve(values);
            } catch (err) {
                alert('Error: ' + err.message);
            }
        });
    }

    function initTextField() {
        $('#function').val(expr);
    }

    function getValues() {
        var values = [];
        for (var x = min; x <= max; x += step) {
            try {
                var y = tree.evaluate({ x }) * scale;
                values.push({ x, y });
            } catch (err) {
                values.push({ x, y: NaN });
            }
        }
        return values;
    }

    //Skaalautumisen parantaminen -malli
    function calculateYRange(values) {
        const yValues = values.map(v => v.y);
        yMin = Math.min(...yValues);
        yMax = Math.max(...yValues);

        const padding = (yMax - yMin) * 0.1;
        yMin -= padding;
        yMax += padding;

        if (yMin === yMax) {
            yMin -= 1;
            yMax += 1;
        }
    }

    //Tulosten printtaaminen
    function displayValues(values) {
        const output = $('#output');
        let outputText = "<h4>The values:</h4>";

        outputText += '<div id="grid" style="display: grid; gap: 10px;"></div>';
        output.html(outputText);

        const grid = $('#grid');
        const containerWidth = output.width();
        const columnWidth = 150;
        const columnCount = Math.max(1, Math.floor(containerWidth / columnWidth));

        grid.css({
            'grid-template-columns': `repeat(${columnCount}, 1fr)`,
        });

        const gridItems = values.map(v => `<div>f(${v.x}) = ${v.y.toFixed(2)}</div>`).join('');
        grid.html(gridItems);
    }

    function drawCurve(values) {
        // Tyhjennä canvas
        c.clearRect(0, 0, canvas.width, canvas.height);

        var width = canvas.width;
        var height = canvas.height;

        c.beginPath();
        c.strokeStyle = '#F27C38';

        values.forEach((point, i) => {
            var x = ((point.x - min) / (max - min)) * width; 
            var y = height - ((point.y - yMin) / (yMax - yMin)) * height;

            if (i === 0) {
                c.moveTo(x, y);
            } else {
                c.lineTo(x, y);
            }
        });
        c.stroke();
    }
});
