svg_template_start = """<?xml version="1.0" encoding="utf-8" ?>
<svg width="68" height="68" xmlns="http://www.w3.org/2000/svg">
  <style>
    text {
    font-family: 'Helvetica';
    font-weight: bold;
    dominant-baseline: middle;
    text-anchor: middle;
    fill: white;
    font-size: 1.3mm;
    }
  </style>
  <circle r="34" cx="34" cy="34" />
""";
  
svg_template_end = "</svg>"


labels=["N", "3", "6", "E", "12", "15", "S", "21", "24", "W", "30", "33"]


print(svg_template_start)
i = 0
for label in labels:
    print("""<text x="34" y="34" transform="rotate(%d, 34, 34) translate(0 -23)">%s</text>"""%(i * 30, label));
    i = i + 1

for i in range(0,360,10):
    print("""<rect x="33.75" width="0.5" y="34" height="%d"  transform="rotate(%d, 34, 34) translate(0 -32)" style="fill: white" />"""%(5, i));
    print("""<rect x="33.75" width="0.5" y="34" height="%d"  transform="rotate(%d, 34, 34) translate(0 -32)" style="fill: white" />"""%(4, i + 5));
print(svg_template_end)
