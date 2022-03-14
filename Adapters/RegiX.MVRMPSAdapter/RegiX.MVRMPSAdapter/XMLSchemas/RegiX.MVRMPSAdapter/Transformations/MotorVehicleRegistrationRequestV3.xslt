<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MVR/MPS/GetMotorVehicleRegistrationInfoV3Request" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Входни данни за Разширена справка за МПС по регистрационен номер V3</xsl:text>
						</span>
					</h3>
					<br/>
					<table style="width:100%; " border="0" width="100%">
						<tbody>
							<tr>
								<td width="267">
									<span style="font-style:italic; ">
										<xsl:text>Регистрационен номер на превозно средство:</xsl:text>
									</span>
								</td>
								<td>
									<xsl:for-each select="n1:GetMotorVehicleRegistrationInfoV3Request">
										<xsl:for-each select="n1:Identifier">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
						</tbody>
					</table>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
