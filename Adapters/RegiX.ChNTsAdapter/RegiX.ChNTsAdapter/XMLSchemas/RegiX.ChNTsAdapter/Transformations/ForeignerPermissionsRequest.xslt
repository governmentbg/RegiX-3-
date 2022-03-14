<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h3 align="center">
						<span>
							<xsl:text>Входни параметри на справка за издадени/отказани разрешения за извършване на дейност с нестопанска цел в РБ</xsl:text>
						</span>
					</h3>
					<xsl:for-each select="n1:ForeignerPermissionsRequest">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tbody>
								<tr>
									<td width="300">
										<span style="font-style:italic; ">
											<xsl:text>Дата, към която е извършена справката:</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:SearchDate">
											<span style="font-weight:bold; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
												<xsl:text> г. </xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 12, 2)), '00')"/>
												<xsl:text>:</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 15, 2)), '00')"/>
												<xsl:text>:</xsl:text>
												<xsl:choose>
													<xsl:when test="contains(string(string(.)), 'Z')">
														<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), 'Z'), ':'), ':')), '00')"/>
													</xsl:when>
													<xsl:when test="contains(string(string(.)), '+')">
														<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), '+'), ':'), ':')), '00')"/>
													</xsl:when>
													<xsl:when test="contains(substring(string(string(.)), 18), '-')">
														<xsl:value-of select="format-number(number(substring-before(substring(string(string(.)), 18), '-')), '00')"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="format-number(number(substring(string(string(.)), 18)), '00')"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text> ч.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="300">
										<span style="font-style:italic; ">
											<xsl:text>Имена на латиница:</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:NamesLatin">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="300">
										<span style="font-style:italic; ">
											<xsl:text>Дата на раждане на лицето:</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:BirthDate">
											<span style="font-weight:bold; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text> г.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="300">
										<span style="font-style:italic; ">
											<xsl:text>Личен номер на чужденец:</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:LNCh">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>