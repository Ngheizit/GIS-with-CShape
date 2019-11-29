from PIL import Image
import sys

filename = sys.argv[1]
img = Image.open(filename)


scale = int(sys.argv[2])
icon_sizes = [(scale,scale)]


out = sys.argv[3]
img.save(out, sizes=icon_sizes)