import pandas as pd
import matplotlib.pyplot as plt
from matplotlib.font_manager import FontProperties

# 设置中文字体
font = FontProperties(fname='C:/Windows/Fonts/simhei.ttf')  # 字体路径

# 读取CSV文件
file_paths = ['右上tanxy_output.csv', '右下tanxy_output.csv', '中间tanxy_output.csv', '左上tanxy_output.csv', '左下tanxy_output.csv']
labels = ['右上', '右下', '中间', '左上', '左下']
colors = ['red', 'blue', 'green', 'purple', 'orange']

# 创建一个图形
plt.figure(figsize=(10, 6))

# 读取每个文件并绘制散点图
for file_path, label, color in zip(file_paths, labels, colors):
    data = pd.read_csv(file_path)
    middle_index = len(data) // 2
    middle_data = data.iloc[middle_index - 150:middle_index + 150]  # 取中间的300个数据点
    plt.scatter(middle_data['tanxy_x'], middle_data['tanxy_y'], alpha=0.3, label=label, color=color)

# 添加标题和标签
plt.title('tanxy_x 和 tanxy_y 分布图', fontproperties=font)
plt.xlabel('tanxy_x', fontproperties=font)
plt.ylabel('tanxy_y', fontproperties=font)
plt.grid(True)
plt.legend(prop=font)
plt.show()
